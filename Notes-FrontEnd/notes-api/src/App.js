import { useEffect, useState } from 'react'
import axios from 'axios'
import TextBox from './components/TextBox'
import NotesBackground from './components/NotesBackground'

function App() {

  const [notes, setNotes] = useState([])
  const [confirmationActive, setConfirmationActive] = useState(false)

  useEffect(() => {
      const fetchData = async () => {
          try 
          {
              const response = await axios.get('https://localhost:3100/Note/notes')
              setNotes(response.data)
          }
          catch (error)
          {
              console.error('Error while getting the notes', error)
          }
      }

      fetchData()
  }, [])
  
  async function createNote(param) {
    try 
    {
      const response = await axios.post('https://localhost:3100/Note/create', {
        id: "",
        note: param
      })
      
      const note = response.data

      if (note) 
      {
        const newNotes = await axios.get('https://localhost:3100/Note/notes')
        setNotes(newNotes.data)
      }
    }
    catch (error)
    {
      console.error('Error while creating the note', error)
    }
  }

  async function deleteNote(param) {
    try 
    {
      const response = await axios.delete(`https://localhost:3100/Note/delete?id=${param.id}`)

      const note = response.data

      if (note) 
      {        
        if (notes.length > 1) {
          setNotes([...notes.filter(x => x.id !== param.id)])
          return true
        }
        else {
          return false
        }
      }
    }
    catch (error)
    {
      console.error('Error while deleting the note', error)
    }
  }

  async function updateNote(param) {
    try
    {
      const response = axios.put('https://localhost:3100/Note/update',{
        id: param.id,
        note: param.note
      })

      if(response.data){
        let listNotes = [...notes]
        let updatedNote = listNotes.findIndex(x => x.id === param.id)
        if (updatedNote !== -1) {
          listNotes[updatedNote].note = param.note;
          setNotes(listNotes)
        }
      }
    }
    catch (error) 
    {
      console.error('Error while updating the note', error)
    }
    
  }
  
  return (
    <div className='App'>
      <TextBox onCreateNote={createNote}/>
      <NotesBackground key={notes} notes={notes} onDeleteNote={deleteNote} onUpdateNote={updateNote} confirmationActive={confirmationActive} setConfirmationActive={setConfirmationActive}/>
    </div>
  )
}

export default App