import style from "./index.module.scss";
import Main from "../../layout/Main";
import { Input, Tooltip } from "antd";
import { IoSearchSharp } from "react-icons/io5";
import { IEquipment } from "./types";
import axios from "axios";
import { baseUrl } from "../../utils/baseUrl";
import { useEffect, useRef, useState } from "react";
import Loading from "../../components/Loading/Loading";
import { FaArrowLeft, FaArrowRight } from "react-icons/fa6";
import { photos } from "../../components/Equipments/utils";
import { RootState } from "../../store/store";
import { useSelector } from "react-redux";

const Equipment = () => {
  const imageListRef = useRef<HTMLDivElement | null>(null);
  const language = useSelector((state: RootState) => state.scroll.language);
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
  //  useEffect(() => {
  //     const fetchData = async () => {
  //       setLoading(true);
  //       await axios
  //         .get(baseUrl + `/equipments?searchTerm=${inputValue}`)
  //         .then((res) => {
  //           setEquipments(res?.data?.data);
  //         });
  //       setLoading(false);
  //     };
  //     fetchData();
  //   }, [inputValue]);
  useEffect(() => {
    const fetchData = async () => {
      setLoading(true);
      await axios
        .get(baseUrl + `/equipments?searchTerm=${inputValue}`)
        .then((res) => {
          setEquipments(res?.data?.data);
        });
      setLoading(false);
    };
    fetchData();
  }, [inputValue]);

  if (loading) return <Loading />;

  return (
    <Main>
      <div className={style.tableEquipment}>
        <h2>
          {language === 1
            ? "Texnika və avadanlıqlar"
            : "Machinery and Equipment"}
        </h2>
        <div className={style.search}>
          <Input
            placeholder={language === 1 ? "Axtar..." : "Search..."}
            onPressEnter={(e) => {
              setInputValue(e?.target?.value);
            }}
          />
        </div>
        <table className={style.table}>
          <thead>
            {/* search-da baxarsan */}
            <tr>
              <th style={{ width: "20%" }}>{language === 1 ? "Ad" : "Name"}</th>
              <th style={{ width: "20%" }}>
                {language === 1 ? "Model" : "Model"}
              </th>
              <th style={{ width: "20%" }}>
                {language === 1 ? "Miqdar" : "Quantity"}
              </th>
              <th style={{ width: "40%" }}>
                {language === 1 ? "Təyinatı" : "Purpose"}
              </th>
            </tr>
          </thead>
          <tbody>
            {equipments?.map((equipment: IEquipment) => (
              <tr key={equipment.id}>
                <td>{equipment.name}</td>
                <td>{equipment?.model}</td>
                <td>{equipment?.quantity}</td>
                <td
                  style={{
                    maxWidth: "50px",
                    whiteSpace: "nowrap",
                    overflow: "hidden",
                    textOverflow: "ellipsis",
                  }}>
                  <Tooltip title={equipment?.description}>
                    <span>{equipment?.description}</span>
                  </Tooltip>
                </td>
              </tr>
            ))}
          </tbody>
        </table>
      </div>

      <div className={style.equipment}>
        <h2>{language === 1 ? "Texnikalar" : "Equipment"}</h2>

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
