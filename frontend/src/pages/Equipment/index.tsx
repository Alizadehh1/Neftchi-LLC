import style from './index.module.scss';
import Main from '../../layout/Main';

export const data = [
  {
    age: "age",
  },
  {
    age: "age",
  }, {
    age: "age",
  }, {
    age: "age",
  }, {
    age: "age",
  }, {
    age: "age",
  }, {
    age: "age",
  }, {
    age: "age",
  }, {
    age: "age",
  }, {
    age: "age",
  }, {
    age: "age",
  }, {
    age: "age",
  }, {
    age: "age",
  }, {
    age: "age",
  }, {
    age: "age",
  }, {
    age: "age",
  }, {
    age: "age",
  }, {
    age: "age",
  }, {
    age: "age",
  }, {
    age: "age",
  }, {
    age: "age",
  }, {
    age: "age",
  }, {
    age: "age",
  }, {
    age: "age",
  },
]

const Equipment = () => {
  return (
    <Main>

      <div className={style.tableEquipment}>

        <h2>Texnika və avadanlıqlar</h2>

        <table className={style.table}>
          <thead>
            <tr>
              <th>Təsvir</th>
              <th>Miqdar</th>
              <th>Model</th>
              <th>Təyinatı</th>
              <th>Statusun tarixi</th>
            </tr>
          </thead>
          <tbody>
            {data.map((user) => (
              <tr key={user.age} >
                <td >{user.age}</td>
                <td>{user.age}</td>
                <td >{user.age}</td>
                <td >{user.age}</td>
                <td>{user.age}</td>
              </tr>
            ))}
          </tbody>
        </table>

      </div>


      <div className={style.equipment}>
        <h2>Avadanlıqlar</h2>

        <div className={style.equipmentImages}>
          {[...Array(6)].map((_) => (
            <figure>
              <img src={"https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcQ1zwhySGCEBxRRFYIcQgvOLOpRGqrT3d7Qng&s"} />
            </figure>
          ))}
        </div>

        <button>Daha çoxunu gör</button>

      </div>


    </Main>
  )
}

export default Equipment
