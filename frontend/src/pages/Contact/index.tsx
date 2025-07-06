import Main from "../../layout/Main";
import LogoNeft from "../../assets/LogoNeft.png";
import style from "./index.module.scss";
import { RootState } from "../../store/store";
import { useSelector } from "react-redux";

const Contact = () => {
  const language = useSelector((state: RootState) => state.scroll.language);
  return (
    <Main>
      <div className={style.container}>
        <h2 className={style.aboutTitle}>
          {language === 1 ? "Bizimlə əlaqə" : "Contact Us"}
        </h2>
      </div>

      <div className={style.content}>
        <figure>
          <img src={LogoNeft} />
        </figure>

        <div className={style.contactUs}>
          <div>
            <span>{language === 1 ? "Ünvan" : "Address"}</span>
            <h2>
              {language === 1
                ? "AZ 1801, Şirvan şəhəri, Naxçıvan küçəsi 53A"
                : "53A Nakhchivan Street, Shirvan City, AZ 1801"}
            </h2>
          </div>
          <div>
            <span>{language === 1 ? "Əlaqə" : "Contact"}</span>
            <h2>(+994 50) 205 85 55</h2>
          </div>
          <div>
            <span>{language === 1 ? "Mail adresi" : "Email Address"}</span>
            <h2>info@neftchi-smf.com</h2>
          </div>
        </div>
      </div>
    </Main>
  );
};

export default Contact;
