import { useEffect, useState } from "react";
import style from "./Services.module.scss";
import { SERVICES_PATH } from "../../../utils/routes";
import { useNavigate } from "react-router-dom";
import { IServices } from "./types";
import axios from "axios";
import { baseUrl } from "../../../utils/baseUrl";
import Loading from "../../Loading/Loading";
import { RootState } from "../../../store/store";
import { useSelector } from "react-redux";

const Services = () => {
  const navigate = useNavigate();
  const language = useSelector((state: RootState) => state.scroll.language);
  const [loading, setLoading] = useState(false);
  const [services, setServices] = useState<IServices[]>([]);

  const fetchData = async () => {
    setLoading(true);
    await axios.get(baseUrl + "/services").then((res) => {
      setServices(res?.data?.data);
    });
    setLoading(false);
  };

  useEffect(() => {
    fetchData();
  }, []);

  if (loading) return <Loading />;

  return (
    <div className={style.services}>
      <div className={style.serviceTitle}>
        <h2 style={{ visibility: "hidden" }}>asfasf</h2>
        <h2>{language === 1 ? "Xidmətlərimiz" : "Our Services"}</h2>
        <div
          onClick={() => navigate(SERVICES_PATH)}
          className={style.equipmentMore}>
          {language === 1 ? "Daha çox məlumat al" : "More information"}
        </div>
      </div>

      <div className={style.servicesMenu}>
        <ul>
          {services?.slice(0, 12).map((service: IServices) => (
            <li>{service?.name}</li>
          ))}
        </ul>

        <div
          onClick={() => navigate(SERVICES_PATH)}
          className={style.equipmentMoreResponsive}>
          {language === 1 ? "Daha çox məlumat al" : "More information"}
        </div>
      </div>
    </div>
  );
};

export default Services;
