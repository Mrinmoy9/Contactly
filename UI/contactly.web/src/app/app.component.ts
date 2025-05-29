import { HttpClient, HttpClientModule } from '@angular/common/http';
import { Component, inject } from '@angular/core';
import { Observable } from 'rxjs';
import { Contact } from '../models/contact.model';
import { AsyncPipe } from '@angular/common';
import { FormGroup, FormControl, ReactiveFormsModule,FormsModule } from '@angular/forms';

@Component({
  selector: 'app-root',
  standalone: true,
  imports: [AsyncPipe, HttpClientModule, ReactiveFormsModule, FormsModule],
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css'] // fixed typo here: styleUrls instead of styleUrl
})
export class AppComponent {
  http = inject(HttpClient);

  contactsForm = new FormGroup({
    id: new FormControl<string>(''),   // disabled hata diya
    name: new FormControl<string>('', { nonNullable: true }),
    email: new FormControl<string | null>(''),
    phone: new FormControl<string>('', { nonNullable: true }),
    favorite: new FormControl<boolean>(false, { nonNullable: true })
  });
  

  contact$!: Observable<Contact[]>;

  editMode = false;
  editContactId: string | null = null;
  contacts: Contact[] = [];
  searchName: string = '';
  

  ngOnInit() {
    this.contact$ = this.getContacts(); // Load initial contacts
}
  
onSearch() {
  const query = this.searchName.trim();
  if (query === '') {
    // If query is empty, load all contacts by re-assigning contact$
    this.contact$ = this.getContacts();
  } else {
    
    this.contact$ = this.http.get<Contact[]>(`https://localhost:7230/api/Contacts/${query}`);

    
  }
}

  // When form submits: add or update based on editMode
  onformSubmit() {
    if (this.contactsForm.invalid) {
      alert('Please fill all required fields correctly.');
      return;
    }
   
    if (this.editMode && this.editContactId) {
      this.updateContact();
    } else {
      const addedContact = {
        name: this.contactsForm.get('name')?.value ?? '',
        email: this.contactsForm.get('email')?.value ?? '',
        phone: this.contactsForm.get('phone')?.value ?? '',
        favorite: this.contactsForm.get('favorite')?.value ?? false
      };
  
      this.http.post<Contact>('https://localhost:7230/api/Contacts', addedContact)
        .subscribe({
          next: (value) => {
            console.log('Contact added successfully', value);
            this.contact$ = this.getContacts();
            this.contactsForm.reset();
          },
          error: (err) => {
            alert('Failed to add contact');
            console.error(err);
          }
        });
    }
  }
  

  // Called when clicking Edit icon on a contact
  onEditContact(contact: Contact) {
    this.editMode = true;             // Enter edit mode
    this.editContactId = contact.id;  // Set the contact ID we want to update
    this.contactsForm.patchValue({
      id: contact.id,
      name: contact.name,
      email: contact.email,
      phone: contact.phone,
      favorite: contact.favorite
    });
  }

  // Update contact on backend
  updateContact() {
    if (!this.editContactId) return;
  
    const updatedContact: Contact = {
      id: this.editContactId,
      name: this.contactsForm.get('name')?.value ?? '',
      email: this.contactsForm.get('email')?.value ?? '',
      phone: this.contactsForm.get('phone')?.value ?? '',
      favorite: this.contactsForm.get('favorite')?.value ?? false
    };
  
    this.http.put<Contact>(`https://localhost:7230/api/Contacts/${this.editContactId}`, updatedContact)
      .subscribe({
        next: (value) => {
          console.log('Contact updated successfully', value);
          this.contact$ = this.getContacts();
          this.contactsForm.reset();
          this.editMode = false;
          this.editContactId = null;
        },
        error: (err) => {
          alert('Failed to update contact');
          console.error(err);
        }
      });
  }
  

  // Cancel edit resets form and mode
  onCancelEdit() {
    this.contactsForm.reset();
    this.editMode = false;
    this.editContactId = null;
  }

  // Delete contact by id
  onDeleteContact(id: string) {
    this.http.delete(`https://localhost:7230/api/Contacts/${id}`)
      .subscribe({
        next: () => {
          alert('Contact deleted successfully');
          this.contact$ = this.getContacts();
        }
      });
  }

  // Get list of contacts
  private getContacts(): Observable<Contact[]> {
    return this.http.get<Contact[]>('https://localhost:7230/api/Contacts');
  }
}
  