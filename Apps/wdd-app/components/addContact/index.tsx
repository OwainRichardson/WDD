import React from "react";
import { createPhoneBookEntry } from '../../services/phoneBookService';

export default function ContactList() {

    function openForm() {
        const entryForm = document.getElementById('add-contact-form');
        entryForm?.classList.remove('hidden');
    }

    function saveContact() {
        let firstName = document.getElementById('firstName').value;
        let lastName = document.getElementById('lastName').value;
        let phoneNumber = document.getElementById('phoneNumber').value;

        console.log(firstName);
        console.log(lastName);
        console.log(phoneNumber);

        createPhoneBookEntry(firstName, lastName, phoneNumber)
            .then(() => {
                const entryForm = document.getElementById('add-contact-form');
                entryForm?.classList.add('hidden');

                document.getElementById('firstName').value = '';
                document.getElementById('lastName').value = '';
                document.getElementById('phoneNumber').value = '';
            });
    }

    return (
        <div>
            <div className='add-contact-button' onClick={openForm}>+ Add Contact</div>
            <div id="add-contact-form" className='hidden'>
                <div className='form-group'>
                    <label>First name</label>
                    <input type='text' id='firstName' />
                </div>
                <div className='form-group'>
                    <label>Last name</label>
                    <input type='text' id='lastName' />
                </div>
                <div className='form-group'>
                    <label>Phone number</label>
                    <input type='text' id='phoneNumber' />
                </div>
                <div className='add-contact-button no-bottom-margin' onClick={saveContact}>Save</div>
            </div>
        </div>
    )
}