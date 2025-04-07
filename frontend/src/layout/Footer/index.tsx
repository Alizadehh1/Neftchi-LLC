import style from './index.module.scss';
import Logo from "../../assets/Logo.png";
import { FacebookIcon, InstagramIcon, LinkedinIcon, TwitterIcon, YoutubeIcon } from './utils';

const LocationIcon = () => {
    return (
        <svg xmlns="http://www.w3.org/2000/svg" width="20" height="20" viewBox="0 0 20 20" fill="none">
            <path fill-rule="evenodd" clip-rule="evenodd" d="M9.99984 1.6665C13.2248 1.6665 15.8332 4.27484 15.8332 7.49984C15.8332 11.8748 9.99984 18.3332 9.99984 18.3332C9.99984 18.3332 4.1665 11.8748 4.1665 7.49984C4.1665 4.27484 6.77484 1.6665 9.99984 1.6665ZM5.83345 7.50012C5.83345 9.87512 8.26678 13.5085 10.0001 15.7334C11.7668 13.4918 14.1668 9.90012 14.1668 7.50012C14.1668 5.20012 12.3001 3.33345 10.0001 3.33345C7.70012 3.33345 5.83345 5.20012 5.83345 7.50012ZM9.99988 9.58322C8.84929 9.58322 7.91655 8.65048 7.91655 7.49988C7.91655 6.34929 8.84929 5.41655 9.99988 5.41655C11.1505 5.41655 12.0832 6.34929 12.0832 7.49988C12.0832 8.65048 11.1505 9.58322 9.99988 9.58322Z" fill="#13436B" />
        </svg>
    )
}

const MessageIcon = () => {
    return (
        <svg xmlns="http://www.w3.org/2000/svg" width="20" height="20" viewBox="0 0 20 20" fill="none">
            <path fill-rule="evenodd" clip-rule="evenodd" d="M18.3332 5.00004C18.3332 4.08337 17.5832 3.33337 16.6665 3.33337H3.33317C2.4165 3.33337 1.6665 4.08337 1.6665 5.00004V15C1.6665 15.9167 2.4165 16.6667 3.33317 16.6667H16.6665C17.5832 16.6667 18.3332 15.9167 18.3332 15V5.00004ZM16.6665 5.00004L9.99984 9.16671L3.33317 5.00004H16.6665ZM16.6665 15H3.33317V6.66671L9.99984 10.8334L16.6665 6.66671V15Z" fill="#13436B" />
        </svg>
    )
}

const TelephoneIcon = () => {
    return (
        <svg xmlns="http://www.w3.org/2000/svg" width="20" height="20" viewBox="0 0 20 20" fill="none">
            <path fill-rule="evenodd" clip-rule="evenodd" d="M5.45 4.16667C5.5 4.90833 5.625 5.63333 5.825 6.325L4.825 7.325C4.48333 6.325 4.26667 5.26667 4.19167 4.16667H5.45ZM13.6667 14.1833C14.375 14.3833 15.1 14.5083 15.8333 14.5583V15.8C14.7333 15.725 13.675 15.5083 12.6667 15.175L13.6667 14.1833ZM6.25 2.5H3.33333C2.875 2.5 2.5 2.875 2.5 3.33333C2.5 11.1583 8.84167 17.5 16.6667 17.5C17.125 17.5 17.5 17.125 17.5 16.6667V13.7583C17.5 13.3 17.125 12.925 16.6667 12.925C15.6333 12.925 14.625 12.7583 13.6917 12.45C13.6083 12.4167 13.5167 12.4083 13.4333 12.4083C13.2167 12.4083 13.0083 12.4917 12.8417 12.65L11.0083 14.4833C8.65 13.275 6.71667 11.35 5.51667 8.99167L7.35 7.15833C7.58333 6.925 7.65 6.6 7.55833 6.30833C7.25 5.375 7.08333 4.375 7.08333 3.33333C7.08333 2.875 6.70833 2.5 6.25 2.5Z" fill="#13436B" />
        </svg>
    )
}

const Footer = () => {
    return (
        <div className={style.footer}>
            <div className={style.content}>

                <div className={style.left}>
                    <figure>
                        <img src={Logo} />
                    </figure>

                    <div className={style.footerContent}>
                        <div className={style.flex}>
                            <span><LocationIcon /></span>
                            <span>AZ 1801, Şirvan şəhəri, Naxçıvan küçəsi 53A</span>
                        </div>
                        <div className={style.flex}>
                            <span><MessageIcon /></span>
                            <span>info@neftchi-smf.com</span>
                        </div>
                        <div className={style.flex}>
                            <span><TelephoneIcon /></span>
                            <span>(+994 50) 205 85 55</span>
                        </div>
                    </div>

                    <div className={style.sosialIcons}>
                        <div><FacebookIcon /></div>
                        <div><InstagramIcon /></div>
                        <div><LinkedinIcon /></div>
                        <div><YoutubeIcon /></div>
                        <div><TwitterIcon /></div>
                    </div>
                </div>


                <div className={style.right}>
                    <div>
                        <h2>Haqqımızda</h2>
                        <p>Texniki Avadanlıqlar</p>
                    </div>
                    <div>
                        <h2>Xidmətlər</h2>
                        <p>Əməkdaşlarımız</p>
                    </div>
                    <div>
                        <h2>Portfolio</h2>
                        <p>Layihələrimiz</p>
                    </div>
                </div>

            </div>

            <hr style={{ borderColor: "#8fceff", marginTop: "50px" }} />

            <p className={style.copyright}>Copyrighted © 2025  Neftchi LLC</p>
        </div>
    )
}

export default Footer
