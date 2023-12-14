import './CreateButton.css'

const CreateButton = (props) => {
    return (
        <button className='button'>
            {props.children}
        </button>
    )
}

export default CreateButton