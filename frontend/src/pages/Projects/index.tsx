import Main from '../../layout/Main'
import style from "./index.module.scss";

const Projects = () => {
  return (
    <Main> 
      <div className={style.container}>
        <h2>Layihələrimiz</h2>

        <div className={style.images}>
          {[...Array(6)].map((_) => (
            <div className={style.figure}>
              <img src={"https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcQ1zwhySGCEBxRRFYIcQgvOLOpRGqrT3d7Qng&s"} />
            </div>
          ))}
        </div>

      </div>
    </Main>
  )
}

export default Projects
