import Main from '../../layout/Main'
import LogoNeft from "../../assets/LogoNeft.png";
import style from "./index.module.scss";

const Contact = () => {
    return (
        <Main>
            <div className={style.container}>
                <h2 className={style.aboutTitle}>
                    Bizimlə əlaqə
                </h2>
            </div>

            <div className={style.content}>

                <figure>
                    <img src={LogoNeft} />
                </figure>

                <div className={style.contactUs}>
                    <div>
                        <span>Ünvan</span>
                        <h2>AZ 1801, Şirvan şəhəri, Naxçıvan küçəsi 53A</h2>
                    </div>
                    <div>
                        <span>Əlaqə</span>
                        <h2>Hüseyn Abaslı  / (+994 50) 205 85 55</h2>
                    </div>
                    <div>
                        <span>Mail adresi</span>
                        <h2>info@neftchi-smf.com</h2>
                    </div>
                </div>

            </div>
        </Main>

    )
}

export default Contact
