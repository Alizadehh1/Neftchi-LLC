import style from './index.module.scss';
import Main from '../../layout/Main';
import Hero from "../../assets/Hero.png";
import { FaArrowRight, FaArrowLeft } from "react-icons/fa6";
import Partners from '../../components/Partners';
import Equipments from '../../components/Equipments';
import { useNavigate } from 'react-router-dom';
import { PROJECT_PATH } from '../../utils/routes';

const Home = () => {
    const navigate = useNavigate();

    return (
        <Main>
            <div className={style.container}>

                <div className={style.hero}>
                    <img src={Hero} alt={""} />
                </div>

                <div className={style.about}>
                    <h2>Haqqımızda</h2>

                    <div className={style.section}>

                        <div className={style.sectionImage}>
                            <img src={"https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcQ1zwhySGCEBxRRFYIcQgvOLOpRGqrT3d7Qng&s"} />
                        </div>

                        <div className={style.sectionInfo}>
                            <p>NEFTÇI IQ Firması sizə ümumi məlumat üçün bildirir ki, 2001-ci ildə əsası qoyulmuş bu şirkət keçmiş "Qafqazenerjiquraçdırma" trestinin kollektivindən ibarət yüksək səviyyəli peşəkar quraşdırıcılardan və beynəlxalq sertifikat almış elektrik qaynaqçılardan ibarət taşkil olunmuşdur.</p>
                            <div className={style.sectionAbout}>
                                <span className={style.sectionIcon}>
                                    <FaArrowRight />
                                </span>
                                <span className={style.sectionMore}>Daha çox məlumat al</span>
                            </div>
                        </div>

                    </div>

                </div>

                <div className={style.services}>

                    <div className={style.serviceTitle}>
                        <h2 style={{ visibility: "hidden" }}>asfasf</h2>
                        <h2>Xidmətlərimiz</h2>
                        <div className={style.servicesArrow}>
                            <div >
                                <FaArrowLeft />
                            </div>
                            <div >
                                <FaArrowRight />
                            </div>
                        </div>
                    </div>

                    <div className={style.servicesMenu}>
                        <ul>
                            {[...Array(6)].map((_, index) => (
                                <li key={index}>Həcmi 30.000m3-dək olan rezervuarların quraşdırılması və təmiri</li>
                            ))}
                        </ul>
                        <ul>
                            {[...Array(6)].map((_, index) => (
                                <li key={index}>Həcmi 30.000m3-dək olan rezervuarların quraşdırılması və təmiri</li>
                            ))}
                        </ul>
                        <ul>
                            {[...Array(6)].map((_, index) => (
                                <li key={index}>Həcmi 30.000m3-dək olan rezervuarların quraşdırılması və təmiri</li>
                            ))}
                        </ul>
                    </div>

                </div>



                <Equipments />

                <Partners />


                <div className={style.projects}>

                    <div className={style.projectsTitle}>
                        <h2 style={{ visibility: "hidden" }}>asfasf</h2>
                        <h2 className={style.projectsTitleValue}>Layihələrimiz</h2>
                        <div onClick={() => navigate(PROJECT_PATH)} className={style.projectsTitleMore}>
                            Daha çox məlumat al
                        </div>
                    </div>

                    <div className={style.projectImages}>
                        {[...Array(3)].map((_) => (
                            <figure>
                                <img src={"https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcQ1zwhySGCEBxRRFYIcQgvOLOpRGqrT3d7Qng&s"} />
                            </figure>
                        ))}
                        <div onClick={() => navigate(PROJECT_PATH)} className={style.projectsResponsiveTitleMore}>
                            Daha çox məlumat al
                        </div>
                    </div>

                </div>



            </div>
        </Main>
    )
}

export default Home
