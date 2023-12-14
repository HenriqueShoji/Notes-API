import { FontAwesomeIcon } from '@fortawesome/react-fontawesome'
import { faTrash } from '@fortawesome/free-solid-svg-icons'
import './Text.css'

const Text = ({value, onChange, onDelete, required, placeholder, trashVisible, setVisible}) => {

    const onType = (event) => {
        onChange(event.target.value)
        if (event.target.value.length > 0) {
            setVisible(true)
        }
        else {
            setVisible(false)
        }
    }

    const onClick = (x) => {
        onDelete()
        setVisible(false)
    }
    
    return (
        <div className='text'>
            <input value={value} onChange={onType} required={required} placeholder={placeholder}/>
            {trashVisible ? <button onClick={onClick}><FontAwesomeIcon icon={faTrash} size="3x" /></button> : ""}
        </div>
    )
}

export default Text