import style from "./index.module.scss";
import Main from '../../layout/Main';
import axios from "axios";
import { baseUrl } from "../../utils/baseUrl";
import { useEffect, useState } from "react";
import { IServices } from "./types";
import Loading from "../../components/Loading/Loading";

const Services = () => {
    const [loading, setLoading] = useState(false);
    const [services, setServices] = useState<IServices[]>([]);


    const fetchData = async () => {
        setLoading(true);
        await axios.get(baseUrl + "/services").then(res => {
            setServices(res?.data?.data)
        })
        setLoading(false);
    }

    useEffect(() => {
        fetchData();
    }, [])

    if (loading) return <Loading />

    return (
        <Main>
            <div className={style.container}>

                <div className={style.about}>
                    <h2 className={style.servicesValue}>Xidmətlərimiz</h2>
                    <p>NEFTÇİ İQ Firması sizə ümumi məlumat üçün bildirir ki, 2001-ci ildə əsası qoyulmuş bu şirkət keçmiş "Qafqazenerjiquraşdırma" trestinin kollektivindən ibarət yüksək səviyyəli peşəkar quraşdırıcılardan və beynəlxalq sertifikat almış elektrik qaynaqçılardan ibarət taşkil olunmuşdur.</p>
                </div>

                <hr className={style.element} />

                <div className={style.content}>
                    {services?.map((data: IServices) => (
                        <div className={style.col}>
                            <h2>{data?.rank}</h2>
                            <span>{data?.name}</span>
                        </div>
                    ))}
                </div>

            </div>
        </Main>
    )
}

export default Services
