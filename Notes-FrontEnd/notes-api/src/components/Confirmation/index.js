import React, { useState } from 'react'
import Modal from 'react-modal'
import './Confirmation.css'

const Confirmation = ({ confirmation, onConfirm, onCancel }) => {

  const [modalOpen, setModalOpen] = useState(true)

  function closeModal() {
    setModalOpen(false)
  }

  const handleClickConfirm = () => {
    onConfirm()
    closeModal()
  }

  const handleClickCancel = () => {
    onCancel()
    closeModal()
  }

  return (
    <div>
      <Modal className="confirmation" isOpen={modalOpen} onRequestClose={closeModal} shouldCloseOnOverlayClick={false} shouldCloseOnEsc={false}>
        <h3>{confirmation}</h3>
        <button className="confirm" onClick={handleClickConfirm}>
          Confirm
        </button>
        <button className="cancel" onClick={handleClickCancel}>
          Cancel
        </button>
      </Modal>
    </div>
  )
}

export default Confirmation
