import Head from 'next/head'
import Image from 'next/image'
import styles from '../styles/Home.module.css'
import AddContact from '../components/addContact'
import ContactList from '../components/contactList'

export default function Home() {
  return (
    <div className={styles.container}>
      <Head>
        <title>Create Next App</title>
        <meta name="description" content="Generated by create next app" />
        <link rel="icon" href="/favicon.ico" />
      </Head>

      <main className={styles.main}>
        <h1 className={styles.title}>
          Phone Book App
        </h1>

        <AddContact />
        <ContactList />
      </main>
    </div>
  )
}
