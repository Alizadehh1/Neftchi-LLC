import { BrowserRouter, Route, Routes } from 'react-router-dom'
import Home from './pages/Home'
import { ABOUT_PATH, CONTACT_PATH, EQUIPMENT_PATH, PORTFOLIO_PATH, PROJECT_PATH, SERVICES_PATH } from './utils/routes'
import About from './pages/About'
import Portfolio from './pages/Portfolio'
import Equipment from './pages/Equipment'
import Contact from './pages/Contact'
import Projects from './pages/Projects'
import Services from './pages/Services'

const Routing = () => {
  return (
    <BrowserRouter>
      <Routes>
        <Route path={'/'} element={<Home />} />
        <Route path={ABOUT_PATH} element={<About />} />
        <Route path={PORTFOLIO_PATH} element={<Portfolio />} />
        <Route path={EQUIPMENT_PATH} element={<Equipment />} />
        <Route path={CONTACT_PATH} element={<Contact />} />
        <Route path={PROJECT_PATH} element={<Projects />} />
        <Route path={SERVICES_PATH} element={<Services />} />
      </Routes>
    </BrowserRouter>
  )
}

export default Routing
