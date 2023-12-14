import { FontAwesomeIcon } from '@fortawesome/react-fontawesome'
import { faTrash } from '@fortawesome/free-solid-svg-icons'
import { useState } from 'react'
import Confirmation from '../Confirmation'
import './DeleteButton.css'

const DeleteButton = ({note, onDelete}) => {

    const [showPopup, setShowPopup] = useState(false)
    
    const showConfirmation = () => {
        setShowPopup(true)
    }

    const onClick = () => {
       onDelete(note)
    }

    return (
        <>
            <button className='delete-button' onClick={showConfirmation}>
                <FontAwesomeIcon icon={faTrash} size='2x' />
            </button>
            {(showPopup && <Confirmation confirmation='Are you sure you want to delete your note?' onCancel={() => setShowPopup(false)} onConfirm={onClick}/>)}
        </>
    )
}

export default DeleteButton
