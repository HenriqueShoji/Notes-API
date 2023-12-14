import { FontAwesomeIcon } from '@fortawesome/react-fontawesome'
import { faPenToSquare } from '@fortawesome/free-solid-svg-icons'
import './PenButton.css'

const PenButton = (props) => {

    const updateNote = () => {
        props.onUpdate()
    }

    return (
        <button className='pen-button' onClick={updateNote}>
            <FontAwesomeIcon icon={faPenToSquare} size='2x' />
        </button>
    )
}

export default PenButton