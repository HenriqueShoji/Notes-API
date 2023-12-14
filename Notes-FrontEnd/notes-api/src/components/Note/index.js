import { useState } from 'react'
import DeleteButton from '../DeleteButton'
import PenButton from '../PenButton';
import UpdateInput from '../UpdateInput';
import UpdateButton from '../UpdateButton';
import './Note.css'

const Note = ({ note, onDeleteNote, onUpdateNote, confirmationActive, setConfirmationActive }) => {

  const [isVisible, setIsVisible] = useState(true);
  const [hideNote, setHideNote] = useState(true);
  const [newNote, setNote] = useState(note.note);
  const [updateIsVisible, setUpdateVisible] = useState(false);

  const onClick = async () => {
    note.note = newNote
    await onUpdateNote(note)
    setHideNote(true)
    setUpdateVisible(false)
  }

  const handleDeleteNote = async () => {
    setConfirmationActive(true); // Ativa a confirmação
    const deleted = await onDeleteNote(note);
    if (!deleted) {
      window.location.reload()
    } else {
      setIsVisible(false)
      setConfirmationActive(false)
    }
  }

  const changeNote = () => {
    setNote(note.note)
    setHideNote(!hideNote)
    setUpdateVisible(true)
  }

  const onType = (event) => {
    setNote(event.target.value)
  }

  return (
    isVisible && (
      <div className={`note-container${confirmationActive ? ' confirmation-active' : ''}`}>
        {hideNote && <h3>{note.note}</h3>}
        {!hideNote && <UpdateInput value={newNote} onChange={onType}/>}
        {!hideNote && updateIsVisible && <UpdateButton onClick={() => onClick()}>Update Note</UpdateButton>}
        <DeleteButton note={note} onDelete={handleDeleteNote} />
        <PenButton onUpdate={() => changeNote()}/>
      </div>
    )
  )
}

export default Note