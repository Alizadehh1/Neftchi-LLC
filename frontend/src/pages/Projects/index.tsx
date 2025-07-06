import { useEffect, useState } from "react";
import Main from "../../layout/Main";
import style from "./index.module.scss";
import { IProject } from "../../components/Home/Projects/types";
import axios from "axios";
import Loading from "../../components/Loading/Loading";
import { baseUrl } from "../../utils/baseUrl";
import Modal from "../../components/Modal";
import AboutProject from "./AboutProject";
import { RootState } from "../../store/store";
import { useSelector } from "react-redux";

const Projects = () => {
  const [loading, setLoading] = useState(false);
  const [projects, setProject] = useState<IProject[]>([]);
  const [modalVisible, setModalVisible] = useState(false);
  const [oneProject, setOneProject] = useState();
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

  const getById = async (id: number) => {
    setLoading(true);
    await axios.get(baseUrl + `/projects/${id}`).then((res) => {
      setOneProject(res?.data?.data);
    });
    setLoading(false);
  };

  if (loading) return <Loading />;

  return (
    <Main>
      <Modal visible={modalVisible} setVisible={setModalVisible}>
        <AboutProject project={oneProject} language={language} />
      </Modal>

      <div className={style.container}>
        <h2>{language === 1 ? "Layihələrimiz" : "Our Projects"}</h2>

        <div className={style.images}>
          {projects.map((project: IProject) => (
            <div className={style.figure}>
              <div
                onClick={() => {
                  getById(project?.id);
                  setModalVisible(true);
                }}
                className={style.more}>
                {language === 1 ? "Detalları" : "Details"}
              </div>
              <img src={project?.file?.path} />
            </div>
          ))}
        </div>
      </div>
    </Main>
  );
};

export default Projects;
