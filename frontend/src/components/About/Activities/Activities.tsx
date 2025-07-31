import { useEffect, useState } from "react";
import style from "./Activities.module.scss";
import axios from "axios";
import { baseUrl } from "../../../utils/baseUrl";
import { IActivites, ICompletedWorks } from "./types";
import Loading from "../../Loading/Loading";

const Activities = ({ language }: any) => {
  const [activities, setActivities] = useState<IActivites[]>([]);
  const [completedWorks, setCompletedWorks] = useState<ICompletedWorks[]>([]);
  const [loading, setLoading] = useState(false);

  const fetchActivities = async () => {
    try {
      const response = await axios.get(baseUrl + "/activities");
      setActivities(response?.data?.data);
    } catch (error) {
      console.error("Error fetching activities:", error);
    }
  };

  const fetchCompletedWorks = async () => {
    try {
      const response = await axios.get(baseUrl + "/completedworks");
      setCompletedWorks(response?.data?.data);
    } catch (error) {
      console.error("Error fetching completed works:", error);
    }
  };

  useEffect(() => {
    const fetchData = async () => {
      await Promise.all([fetchActivities(), fetchCompletedWorks()]);
      setLoading(false);
    };

    fetchData();
  }, []);

  if (loading) return <Loading />;

  return (
    <div className={style.content}>
      <div className={style.contentMenu}>
        <div className={style.contentWorks}>
          <h2>
            {language === 1
              ? "İxtisaslaşma sahələri və təcrübə"
              : "Areas of Specialization and Experience"}
          </h2>
          <ul>
            {activities?.map((activity: IActivites, index) => (
              <li key={index}>{activity?.description}</li>
            ))}
          </ul>
        </div>

        <div className={style.contentActivities}>
          <h2>{language === 1 ? "Üstünlüklərimiz" : "Our Advantages"}</h2>
          <ul>
            {completedWorks?.map((completedWork: ICompletedWorks, index) => (
              <li key={index}>{completedWork?.description}</li>
            ))}
          </ul>
        </div>
      </div>

      {/* bunedi statik yoxsa dinamik */}
      <br />

      <div className={style.contentMenu}>
        <div className={style.contentWorks}>
          <h2>
            {language === 1
              ? "Əməkdaşlıq Etdiyimiz Tərəfdaşlar"
              : "Our Partners"}
          </h2>
          <ul>
            <li>SOCAR - Magistral Neft Kəmərləri İstehsalat Birliyi</li>
            <li>SOCAR - Kompleks Qazma İşləri Tresti</li>
            <li>SOCAR - Azərkimya İstehsalat Birliyi</li>
            <li>SOCAR - Neft Qaz Tikinti Tresti</li>
            <li>GL Group</li>
            <li>Taghiyev Operating Company</li>
            <li>Salyan Oil Limited</li>
            <li>Balakhani Operating Company</li>
            <li>Binagadi Oil Company</li>
          </ul>
        </div>
        <div className={style.contentActivities}>
          <h2 style={{ color: "transparent", userSelect: "none" }}>* </h2>
          <ul>
            <li>Karasu Operating Company</li>
            <li>Shirvan Operating Company</li>
            <li>Neftechala Operating Company</li>
            <li>Absheron Operating Company</li>
            <li>Surakhani Oil Operation Company</li>
            <li>SOCAR-AQS</li>
            <li>British Petroleum</li>
            <li>Bahar Energy Operating Company</li>
            <li>Zenith Aran Oil Company</li>
          </ul>
        </div>
      </div>
    </div>
  );
};

export default Activities;
