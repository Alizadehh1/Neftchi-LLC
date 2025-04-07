import { useEffect,  useRef } from 'react'
import Main from '../../layout/Main';
import style from './index.module.scss';
import { useDispatch, useSelector } from 'react-redux';
import { setScrollTarget } from '../../store/global';

const About = () => {
    const dispatch = useDispatch();

    const scrollTarget  =  useSelector((state: any) => state.scroll.target)

    const licenseRef = useRef<HTMLDivElement>(null);
    const isoRef = useRef<HTMLDivElement>(null);
    const recommendationRef = useRef<HTMLDivElement>(null);

    useEffect(() => {
        if (scrollTarget) {
            let targetRef: HTMLDivElement | null = null;
            if (scrollTarget === "license") targetRef = licenseRef.current;
            else if (scrollTarget === "iso") targetRef = isoRef.current;
            else if (scrollTarget === "recommendation") targetRef = recommendationRef.current;

            if (targetRef) {
                targetRef.scrollIntoView({ behavior: "smooth", block: "start" });
                dispatch(setScrollTarget(null)); 
            }
        }
    }, [scrollTarget, dispatch]);

    return (
        <Main>

            <div className={style.about}>

                <h2 className={style.aboutTitle}>
                    Haqqımızda
                </h2>

                <div className={style.aboutMenu}>
                    <p>NEFTÇİ İQ Firması sizə ümumi məlumat üçün bildirir ki, 2001-ci ildə əsası qoyulmuş bu şirkət keçmiş "Qafqazenerjiquraşdırma" trestinin kollektivindən ibarət yüksək səviyyəli peşəkar quraşdırıcılardan və beynəlxalq sertifikat almış elektrik qaynaqçılardan ibarət taşkil olunmuşdur.</p>
                    <p>
                        Kollektiv energetika obyektlərində, neft sənayesində və digər sahələrdə özlərini bacarıqlı ixtisasçı kimi göstərmişlər. Onlar aşağıda adları qeyd olunan işlərin quraşdırılması, təmir və tikinti işlərini yerinə yetirmişlər.
                    </p>
                </div>

                <div className={style.aboutImage}>
                    <img src={"https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcQ1zwhySGCEBxRRFYIcQgvOLOpRGqrT3d7Qng&s"} />
                </div>

            </div>

            <hr />

            <div className={style.content}>

                <div className={style.contentMenu}>

                    <div className={style.contentWorks}>
                        <h2>Yerinə yetirdiyimiz işlər</h2>
                        <ul>
                            {[...Array(6)].map((_, index) => (
                                <li key={index}>Həcmi 30.000m3-dək olan rezervuarların quraşdırılması və təmiri</li>
                            ))}
                        </ul>
                    </div>

                    <div className={style.contentActivities}>
                        <h2>Fəaliyyətlərimiz</h2>
                        <ul>
                            {[...Array(6)].map((_, index) => (
                                <li key={index}>Həcmi 30.000m3-dək olan rezervuarların quraşdırılması və təmiri</li>
                            ))}
                        </ul>
                    </div>
                </div>

                <p>Bununla yanaşı məlumat üçün onu da bildiririk ki, həmin kollektivin iş bacarığını əməkdaşlıq etdiyimiz SOCAR, Magistral Neft Kəmərləri istehsalat Birliyi, Xəzər Dəniz Neft Qaz Tikinti, Qaradağ sement zavodu, Şirvan IES (Əli Bayramlı DRES), Karasu Operating Company, Shirvan Operating Company, Neftchala Operating Company, Binagadi OIL Company, Absheron Operating Company, GL LTD, Taghiyev Operating Company , Salyan Oil Limited, Socar-AQS şirkətlərinin rəhbərliyinə məlumdur.</p>

            </div>

            <div ref={licenseRef} className={style.lissenzia}>
                <h2>Lisenziya</h2>
                <div className={style.lisensiaImages}>
                    {[...Array(3)].map((_) => (
                        <figure>
                            <img src={"https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcQ1zwhySGCEBxRRFYIcQgvOLOpRGqrT3d7Qng&s"} />
                        </figure>
                    ))}
                </div>
            </div>

            <div ref={isoRef} className={style.lissenzia}>
                <h2>İSO sertifikatları</h2>
                <div className={style.lisensiaImages}>
                    {[...Array(3)].map((_) => (
                        <figure>
                            <img src={"https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcQ1zwhySGCEBxRRFYIcQgvOLOpRGqrT3d7Qng&s"} />
                        </figure>
                    ))}
                </div>
            </div>

            <div ref={recommendationRef} className={style.lissenzia}>
                <h2>Tövsiyyə məktubları</h2>
                <div className={style.lisensiaImages}>
                    {[...Array(3)].map((_) => (
                        <figure>
                            <img src={"https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcQ1zwhySGCEBxRRFYIcQgvOLOpRGqrT3d7Qng&s"} />
                        </figure>
                    ))}
                </div>
            </div>

        </Main>
    )
}

export default About
