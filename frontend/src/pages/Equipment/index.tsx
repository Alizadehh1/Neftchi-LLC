import style from "./index.module.scss";
import Main from "../../layout/Main";
import { Input } from "antd";
import { IoSearchSharp } from "react-icons/io5";
import { IEquipment } from "./types";
import axios from "axios";
import { baseUrl } from "../../utils/baseUrl";
import { useEffect, useRef, useState } from "react";
import Loading from "../../components/Loading/Loading";
import { FaArrowLeft, FaArrowRight } from "react-icons/fa6";
import { photos } from "../../components/Equipments/utils";

const Equipment = () => {
  const imageListRef = useRef<HTMLDivElement | null>(null);

  const [loading, setLoading] = useState(false);
  const [equipments, setEquipments] = useState<IEquipment[]>([]);
  const [inputValue, setInputValue] = useState("");

  const scroll = (direction: "left" | "right") => {
    if (!imageListRef.current) return;

    const scrollAmount = imageListRef.current.clientWidth * 0.2;
    imageListRef.current.scrollBy({
      left: direction === "right" ? scrollAmount : -scrollAmount,
      behavior: "smooth",
    });
  };

  const fetchData = async () => {
    setLoading(true);
    await axios
      .get(baseUrl + `/equipments?searchTerm=${inputValue}`)
      .then((res) => {
        setEquipments(res?.data?.data);
      });
    setLoading(false);
  };

  useEffect(() => {
    fetchData();
  }, [inputValue]);

  if (loading) return <Loading />;

  return (
    <Main>
      <div className={style.tableEquipment}>
        <h2>Texnika və avadanlıqlar</h2>

        <table className={style.table}>
          <thead>
            {/* search-da baxarsan */}
            <tr>
              <th>Təsvir</th>
              <th>Miqdar</th>
              <th>Model</th>
              <th>Təyinatı</th>
              <th className={style.inputTd}>
                <Input
                  onChange={(e) => setInputValue(e?.target?.value)}
                  prefix={<IoSearchSharp />}
                />
              </th>
            </tr>
          </thead>
          <tbody>
            {equipments?.map((equipment: IEquipment) => (
              <tr key={equipment.id}>
                <td>{equipment.name}</td>
                <td>{equipment?.quantity}</td>
                <td>{equipment?.model}</td>
                <td>{equipment?.description}</td>
                <td></td>
              </tr>
            ))}
          </tbody>
        </table>
      </div>

      <div className={style.equipment}>
        <h2>Avadanlıqlar</h2>

        <div className={style.equipmentImages}>
          <div
            onClick={() => scroll("left")}
            className={style.equipmentRightArrow}>
            <FaArrowLeft />
          </div>

          <div ref={imageListRef} className={style.elements}>
            {photos.map((value) => (
              <figure>
                <img src={value?.photo} />
              </figure>
            ))}
          </div>

          <div
            onClick={() => scroll("right")}
            className={style.equipmentLeftArrow}>
            <FaArrowRight />
          </div>
        </div>
      </div>
    </Main>
  );
};

export default Equipment;
