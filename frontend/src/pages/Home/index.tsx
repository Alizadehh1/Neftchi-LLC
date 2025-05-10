import style from './index.module.scss';
import Main from '../../layout/Main';
import Hero from "../../assets/Hero.png";
import Partners from '../../components/Home/Partners';
import Equipments from '../../components/Equipments';
import AboutUses from '../../components/Home/AboutUses/AboutUses';
import Services from '../../components/Home/Services/Services';
import Projects from '../../components/Home/Projects/Projects';

const Home = () => {

    return (
        <Main>
            <div className={style.container}>

                <div className={style.hero}>
                    <img src={Hero} alt={""} />
                </div>

                <AboutUses />
                <Services />
                <Equipments />
                <Partners />
                <Projects />

            </div>
        </Main>
    )
}

export default Home
