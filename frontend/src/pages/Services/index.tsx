import style from "./index.module.scss";
import Main from "../../layout/Main";
import axios from "axios";
import { baseUrl } from "../../utils/baseUrl";
import { useEffect, useState } from "react";
import { IServices } from "./types";
import Loading from "../../components/Loading/Loading";
import { RootState } from "../../store/store";
import { useSelector } from "react-redux";

const Services = () => {
  const [loading, setLoading] = useState(false);
  const [services, setServices] = useState<IServices[]>([]);
  const language = useSelector((state: RootState) => state.scroll.language);
  const fetchData = async () => {
    setLoading(true);
    const res = await axios.get(baseUrl + "/services");
    setServices(res?.data?.data || []);
    setLoading(false);
  };

  useEffect(() => {
    fetchData();
  }, []);

  if (loading) return <Loading />;

  // Split into two halves
  const mid = Math.ceil(services.length / 2);
  const leftServices = services.slice(0, mid);
  const rightServices = services.slice(mid);

  return (
    <Main>
      <div className={style.container}>
        <div className={style.about}>
          <h2 className={style.servicesValue}>
            {language === 1 ? "Xidmətlərimiz" : "Our Services"}
          </h2>
          <p>
            Sənaye və enerji sahəsində 2001-ci ildən etibarən texniki
            mükəmməllik, davamlı inkişaf və beynəlxalq standartlara uyğunluq
            prinsipləri ilə fəaliyyət göstərən <b> ‘Neftçi’ İQ Firması, </b>
            aşağıdakı ixtisaslaşmış xidmətləri ilə etibarınızın ünvanıdır.
          </p>
        </div>

        <hr className={style.element} />

        <div className={style.content}>
          <div>
            {leftServices.map((data: IServices) => (
              <div key={data.id} className={style.col}>
                <h2>{data.rank}</h2>
                <span>{data.name}</span>
              </div>
            ))}
          </div>
          <div>
            {rightServices.map((data: IServices) => (
              <div key={data.id} className={style.col}>
                <h2>{data.rank}</h2>
                <span>{data.name}</span>
              </div>
            ))}
          </div>
        </div>
        <div className={style.content_sm}>
          <div>
            {services.map((data: IServices) => (
              <div key={data.id} className={style.col}>
                <h2>{data.rank}</h2>
                <span>{data.name}</span>
              </div>
            ))}
          </div>
        </div>
      </div>
    </Main>
  );
};

export default Services;
