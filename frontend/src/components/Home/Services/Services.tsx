import { useEffect, useState } from 'react'
import style from "./Services.module.scss";
import { SERVICES_PATH } from '../../../utils/routes';
import { useNavigate } from 'react-router-dom';
import { IServices } from './types';
import axios from 'axios';
import { baseUrl } from '../../../utils/baseUrl';
import Loading from '../../Loading/Loading';

const Services = () => {
    const navigate = useNavigate();

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
        <div className={style.services}>



            <div className={style.serviceTitle}>
                <h2 style={{ visibility: "hidden" }}>asfasf</h2>
                <h2>Xidmətlərimiz</h2>
                <div
                    onClick={() => navigate(SERVICES_PATH)}
                    className={style.equipmentMore}
                >
                    Daha çox məlumat al
                </div>
            </div>

            <div className={style.servicesMenu}>
                <ul>
                    {services?.slice(0,12).map((service: IServices) => (
                        <li>{service?.name}</li>
                    ))}
                </ul>

                <div
                    onClick={() => navigate(SERVICES_PATH)}
                    className={style.equipmentMoreResponsive}
                >
                    Daha çox məlumat al
                </div>
            </div>

        </div>
    )
}

export default Services