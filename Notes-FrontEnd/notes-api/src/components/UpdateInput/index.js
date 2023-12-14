import './UpdateInput.css'

const UpdateInput = ({value, onChange}) => {
    return (
        <div>
            <input className='update-input' value={value} placeholder='Update your note...' onChange={onChange}/>
        </div>
    )
}

export default UpdateInput