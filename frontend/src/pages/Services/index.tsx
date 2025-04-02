import style from "./index.module.scss";
import { datas } from './utils';
import Main from '../../layout/Main';

const Services = () => {
    return (
        <Main>
            <div className={style.container}>

                <div className={style.about}>
                    <h2 className={style.servicesValue}>Xidmətlərimiz</h2>
                    <p>NEFTÇİ İQ Firması sizə ümumi məlumat üçün bildirir ki, 2001-ci ildə əsası qoyulmuş bu şirkət keçmiş "Qafqazenerjiquraşdırma" trestinin kollektivindən ibarət yüksək səviyyəli peşəkar quraşdırıcılardan və beynəlxalq sertifikat almış elektrik qaynaqçılardan ibarət taşkil olunmuşdur.</p>
                </div>

                <hr className={style.element} />

                <div className={style.content}>
                    {datas?.map((data: any) => (
                        <div className={style.col}>
                            <h2>{data?.id}</h2>
                            <span>{data?.value}</span>
                        </div>
                    ))}
                </div>

            </div>
        </Main>
    )
}

export default Services
