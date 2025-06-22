import style from "./index.module.scss";
import Main from "../../layout/Main";
import Hero from "../../assets/NewHero.jpg";
import Partners from "../../components/Home/Partners";
import Equipments from "../../components/Equipments";
import AboutUses from "../../components/Home/AboutUses/AboutUses";
import Services from "../../components/Home/Services/Services";
import Projects from "../../components/Home/Projects/Projects";
import { RootState } from "../../store/store";
import { useSelector } from "react-redux";

const Home = () => {
  const language = useSelector((state: RootState) => state.scroll.language);
  return (
    <Main>
      <div className={style.container}>
        <div className={style.hero}>
          <img src={Hero} alt={""} />
          {language === 1 ? (
            <h1>
              Keyfiyyət bizim <br /> missiyamızdır!
            </h1>
          ) : (
            <h1>
              Quality is <br /> our mission!
            </h1>
          )}
        </div>

        <AboutUses />
        <Services />
        <Equipments />
        <Partners />
        <Projects />
      </div>
    </Main>
  );
};

export default Home;
