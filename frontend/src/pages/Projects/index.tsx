import { useEffect, useState } from 'react';
import Main from '../../layout/Main'
import style from "./index.module.scss";
import { IProject } from '../../components/Home/Projects/types';
import axios from 'axios';
import Loading from '../../components/Loading/Loading';
import { baseUrl } from '../../utils/baseUrl';
import Modal from '../../components/Modal';
import AboutProject from './AboutProject';

const Projects = () => {
  const [loading, setLoading] = useState(false);
  const [projects, setProject] = useState<IProject[]>([]);
  const [modalVisible, setModalVisible] = useState(false);
  const [oneProject, setOneProject] = useState();

  const fetchData = async () => {
    setLoading(true);
    await axios.get(baseUrl + "/projects").then(res => {
      setProject(res?.data?.data)
    })
    setLoading(false);
  }

  useEffect(() => {
    fetchData();
  }, [])

  const getById = async (id: number) => {
    setLoading(true);
    await axios.get(baseUrl + `/projects/${id}`).then(res => {
      setOneProject(res?.data?.data)
    })
    setLoading(false);
  }

  if (loading) return <Loading />


  return (
    <Main>

      <Modal visible={modalVisible} setVisible={setModalVisible}>
        <AboutProject project={oneProject} />
      </Modal>

      <div className={style.container}>
        <h2>Layihələrimiz</h2>

        <div className={style.images}>
          {projects.map((project: IProject) => (
            <div className={style.figure}>
              <div onClick={() => {
                getById(project?.id)
                setModalVisible(true)
              }}
                className={style.more}>Detalları</div>
              <img src={project?.file?.path} />
            </div>
          ))}
        </div>

      </div>
    </Main>
  )
}

export default Projects
