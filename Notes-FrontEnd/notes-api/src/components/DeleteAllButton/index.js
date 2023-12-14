import axios from 'axios'
import { useState } from 'react'
import './DeleteAllButton.css'
import Confirmation from '../Confirmation'

const DeleteAllButton = (props) => {
    const [showPopup, setShowPopup] = useState(false)

    const showConfirmation = (x) => {
        x.preventDefault()
        setShowPopup(true)
    }

    const onClick = async (x) => {
        setShowPopup(false)
        try {
            const response = await axios.delete('https://localhost:3100/Note/delete/all')

            if (response.data) {
                window.location.reload()
            }
        } catch (error) {
            console.error('Error while creating the note', error)
        }
    }

    return (
        <>
            <button className='delete-all' onClick={showConfirmation}>
                {props.children}
            </button>
            {(showPopup && <Confirmation confirmation='Are you sure you want to delete all your notes?' onCancel={() => setShowPopup(false)} onConfirm={onClick}/>)}
        </>
    );
};

export default DeleteAllButton;
