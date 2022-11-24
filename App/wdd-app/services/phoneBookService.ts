import { TPhoneBookEntry } from '../types/TPhoneBookEntry';

export async function getPhoneBookEntries(): Promise<TPhoneBookEntry[]> {
    const response = await fetch('https://localhost:7206/PhoneBook/GetEntries');

    if (!response.ok) {
        throw response;
    }

    return await response.json();
}

export async function removePhoneBookEntry(entryId: number): Promise<TPhoneBookEntry[]> {
    const response = await fetch('https://localhost:7206/PhoneBook/DeleteEntry?entryId=' + entryId, { method: 'DELETE' });

    if (!response.ok) {
        throw response;
    }

    return await response.json();
}

export async function createPhoneBookEntry(firstName: string, lastName: string, phoneNumber:string) {
    const requestOptions = {
        method: 'POST',
        headers: { 'Content-Type': 'application/json' },
        body: JSON.stringify({ firstName: firstName, lastName: lastName, phoneNumber: phoneNumber })
    };
    return fetch('https://localhost:7206/PhoneBook/CreateEntry', requestOptions)
        .then(response => response.json());
}