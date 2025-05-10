import { ReactNode } from 'react'
import { Modal as AntModal } from "antd";

interface IProps {
    visible?: boolean;
    setVisible: (val: boolean) => void;
    children?: ReactNode
}

const Modal = ({ visible, setVisible, children }: IProps) => {

    const closeModal = () => {
        setVisible(false);
    }

    return (
        <AntModal
            width={918}
            open={visible}
            onCancel={closeModal}
            mask={false}
            maskClosable={false}
            okButtonProps={{
                style: {
                    display: "none"
                }
            }}
            cancelButtonProps={{
                style: {
                    display: "none"
                }
            }}
        >
            {children}
        </AntModal>
    )
}

export default Modal