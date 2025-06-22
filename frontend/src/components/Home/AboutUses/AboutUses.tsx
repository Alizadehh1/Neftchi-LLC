import { useEffect, useState } from "react";
import style from "./AboutUses.module.scss";
import { FaArrowRight } from "react-icons/fa6";
import { IAbout } from "./types";
import axios from "axios";
import { baseUrl } from "../../../utils/baseUrl";
import Loading from "../../Loading/Loading";
import { useNavigate } from "react-router-dom";
import { ABOUT_PATH } from "../../../utils/routes";

const AboutUses = () => {
  const navigate = useNavigate();

  const [loading, setLoading] = useState(false);
  const [aboutUses, setAboutUses] = useState<IAbout[]>([]);

  const fetchData = async () => {
    setLoading(true);
    await axios.get(baseUrl + "/aboutuses").then((res) => {
      setAboutUses(res?.data?.data);
    });
    setLoading(false);
  };

  useEffect(() => {
    fetchData();
  }, []);

  if (loading) return <Loading />;

  return (
    <div className={style.about}>
      <>
        <div className={style.aboutTitle}>
          <h2 style={{ visibility: "hidden" }}>asfasf</h2>
          <h2> {aboutUses[0]?.title}</h2>
          <div
            style={{ visibility: "hidden" }}
            className={style.projectsTitleMore}>
            Daha çox məlumat al
          </div>
        </div>

        <div className={style.section}>
          <div className={style.sectionImage}>
            <img src={aboutUses[0]?.imagePath} />
          </div>
          <div className={style.sectionInfo}>
            <div
              className={style.aboutMenu}
              dangerouslySetInnerHTML={{
                __html: aboutUses[0]?.content,
              }}
            />
            <div className={style.sectionAbout}>
              <span className={style.sectionIcon}>
                <FaArrowRight />
              </span>
              <span
                onClick={() => navigate(ABOUT_PATH)}
                className={style.sectionMore}>
                Daha çox məlumat al
              </span>
            </div>
          </div>
        </div>
      </>
    </div>
  );
};

export default AboutUses;
