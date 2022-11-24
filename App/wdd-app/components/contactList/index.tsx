import React, { useEffect, useState } from "react";
import { TPhoneBookEntry } from "../../types/TPhoneBookEntry";
import { getPhoneBookEntries, removePhoneBookEntry } from '../../services/phoneBookService';

export default function ContactList() {
    const [phoneBookEntries, setPhoneBookEntries] = useState<TPhoneBookEntry[]>([]);

    useEffect(() => {
        getPhoneBookEntries().then((result) => {
            setPhoneBookEntries(result?.phoneBookEntries);
      })
    }, []);

    function removeEntry(entryId: number) {
        removePhoneBookEntry(entryId).then(() => {
            const contact = document.getElementById('contact-' + entryId);
            if (contact) {
                contact.remove();
            }
        });
    }

    return (
        <div className='contact-list'>
            <div className='contact-list-wrapper'>
                {
                    phoneBookEntries.map((entry) => {
                        return (
                                <div key={entry.id} id={'contact-' + entry.id} className='contact'>
                                    <div className='contact__details'>
                                        <h2>{entry.fullName}</h2>
                                        <p className='phone-number'>{entry.phoneNumber} </p>
                                    </div>
                                    <div className='contact__remove'>
                                        <div className='contact__remove__action' onClick={() => removeEntry(entry.id)}>
                                            X
                                        </div>
                                    </div>
                                </div>
                        );
                    })
                }
            </div>
        </div>
    );
}