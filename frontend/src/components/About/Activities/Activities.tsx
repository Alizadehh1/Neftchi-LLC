import { useEffect, useState } from "react";
import style from "./Activities.module.scss";
import axios from "axios";
import { baseUrl } from "../../../utils/baseUrl";
import { IActivites, ICompletedWorks } from "./types";
import Loading from "../../Loading/Loading";

const Activities = () => {
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
          <h2>İxtisaslaşma sahələri və təcrübə</h2>
          <ul>
            {activities?.map((activity: IActivites, index) => (
              <li key={index}>{activity?.description}</li>
            ))}
          </ul>
        </div>

        <div className={style.contentActivities}>
          <h2>Üstünlüklərimiz</h2>
          <ul>
            {completedWorks?.map((completedWork: ICompletedWorks, index) => (
              <li key={index}>{completedWork?.description}</li>
            ))}
          </ul>
        </div>
      </div>

      {/* bunedi statik yoxsa dinamik */}
      <p>
        Bununla yanaşı məlumat üçün onu da bildiririk ki, həmin kollektivin iş
        bacarığını əməkdaşlıq etdiyimiz SOCAR, Magistral Neft Kəmərləri
        istehsalat Birliyi, Xəzər Dəniz Neft Qaz Tikinti, Qaradağ sement zavodu,
        Şirvan IES (Əli Bayramlı DRES), Karasu Operating Company, Shirvan
        Operating Company, Neftchala Operating Company, Binagadi OIL Company,
        Absheron Operating Company, GL LTD, Taghiyev Operating Company , Salyan
        Oil Limited, Socar-AQS şirkətlərinin rəhbərliyinə məlumdur.
      </p>
    </div>
  );
};

export default Activities;
