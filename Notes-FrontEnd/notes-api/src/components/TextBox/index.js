import { useState } from 'react'
import Text from '../Text'
import './TextBox.css'
import CreateButton from '../CreateButton'
import DeleteAllButton from '../DeleteAllButton'


const TextBox = (props) => {

    const [note, setNote] = useState('')
    const [hideTrash, setHideTrash] = useState()
    
    const onSave = (event) => {
      event.preventDefault()
      props.onCreateNote(note)
      setHideTrash(false)
      setNote('')
    }
    
    return (
      <section className='form'>
        <form onSubmit={onSave}>
            <h2>Create your own Note!</h2>
            <Text required={true} placeholder="Type your note" value={note} onChange={value => setNote(value)} onDelete={() => setNote('')} trashVisible={hideTrash} setVisible={setHideTrash}/>
            <CreateButton>
              Create Note
            </CreateButton>
            <DeleteAllButton>
              Delete All Notes
            </DeleteAllButton>
        </form>
      </section>
    )
}

export default TextBox