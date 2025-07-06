import style from "./Projects.module.scss";
import { useNavigate } from "react-router-dom";
import { PROJECT_PATH } from "../../../utils/routes";
import { useEffect, useState } from "react";
import axios from "axios";
import Loading from "../../Loading/Loading";
import { baseUrl } from "../../../utils/baseUrl";
import { IProject } from "./types";
import { RootState } from "../../../store/store";
import { useSelector } from "react-redux";

const Projects = () => {
  const navigate = useNavigate();
  const [loading, setLoading] = useState(false);
  const [projects, setProject] = useState<IProject[]>([]);
  const language = useSelector((state: RootState) => state.scroll.language);
  const fetchData = async () => {
    setLoading(true);
    await axios.get(baseUrl + "/projects").then((res) => {
      setProject(res?.data?.data);
    });
    setLoading(false);
  };

  useEffect(() => {
    fetchData();
  }, []);

  if (loading) return <Loading />;

  return (
    <div className={style.projects}>
      <div className={style.projectsTitle}>
        <h2 style={{ visibility: "hidden" }}>asfasf</h2>
        <h2 className={style.projectsTitleValue}>
          {language === 1 ? "Layihələrimiz" : "Our Projects"}
        </h2>
        <div
          onClick={() => navigate(PROJECT_PATH)}
          className={style.projectsTitleMore}>
          {language === 1 ? "Daha çox məlumat al" : "More information"}
        </div>
      </div>

      <div className={style.projectImages}>
        {projects?.slice(0, 3).map((project: IProject) => (
          <figure>
            <img src={project?.file?.path} />
          </figure>
        ))}
        <div
          onClick={() => navigate(PROJECT_PATH)}
          className={style.projectsResponsiveTitleMore}>
          {language === 1 ? "Daha çox məlumat al" : "More information"}
        </div>
      </div>
    </div>
  );
};

export default Projects;
