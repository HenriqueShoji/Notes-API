import './UpdateButton.css'

const UpdateButton = (props) => {

    const onUpdate = () => {
        props.onClick()
    }

    return (
        <button className='update-button' onClick={onUpdate}>
            {props.children}
        </button>
    )
}

export default UpdateButton