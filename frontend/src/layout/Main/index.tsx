import  { ReactNode } from 'react'
import Header from '../Header'
import Footer from '../Footer'

interface IProps {
    children: ReactNode
}

const Main = ({ children }: IProps) => {
    return (
        <>
            <Header />
            {children}
            <Footer />
        </>

    )
}

export default Main
