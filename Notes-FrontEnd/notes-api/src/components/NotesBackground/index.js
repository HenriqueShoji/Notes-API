import Note from '../Note'
import './NotesBackground.css'

const NotesBackground = ({notes, onDeleteNote, onUpdateNote, confirmationActive, setConfirmationActive}) => {

    if (notes.length === 0) {
        return null
    }
    
    return (
        <section className='notes-background'>
            <h3 className='title'>Inserted Notes!</h3>
            <div className='note'>
                {notes.map((note, index) => (<Note key={index} note={note} onDeleteNote={onDeleteNote} onUpdateNote={onUpdateNote} confirmationActive={confirmationActive} setConfirmationActive={setConfirmationActive}/>))}
            </div>
        </section>
    )
}

export default NotesBackground