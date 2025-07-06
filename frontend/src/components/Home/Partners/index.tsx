import { useEffect, useRef, useState } from "react";
import style from "./index.module.scss";
import { FaArrowRight, FaArrowLeft } from "react-icons/fa6";
import { IPartners } from "./types";
import axios from "axios";
import { baseUrl } from "../../../utils/baseUrl";
import Loading from "../../Loading/Loading";
import { RootState } from "../../../store/store";
import { useSelector } from "react-redux";

const Partners = () => {
  const imageListRef = useRef<HTMLDivElement | null>(null);
  const language = useSelector((state: RootState) => state.scroll.language);
  const [loading, setLoading] = useState(false);
  const [partners, setPartners] = useState<IPartners[]>([]);

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
    await axios.get(baseUrl + "/partners").then((res) => {
      setPartners(res?.data?.data);
    });
    setLoading(false);
  };

  useEffect(() => {
    fetchData();
  }, []);

  if (loading) return <Loading />;

  return (
    <div className={style.partners}>
      <div className={style.partnersTitle}>
        <h2 style={{ visibility: "hidden" }}>asfasf</h2>
        <h2 className={style.partnersTitleValue}>
          {language === 1 ? "Partnyorlarımız" : "Our Partners"}
        </h2>
        <div className={style.partnersArrow}>
          <div onClick={() => scroll("left")}>
            <FaArrowLeft />
          </div>
          <div onClick={() => scroll("right")}>
            <FaArrowRight />
          </div>
        </div>
      </div>

      <div ref={imageListRef} className={style.partnerImages}>
        {partners?.map((partner: IPartners, index) => (
          <figure
            key={index}
            onClick={() => {
              window.open(partner?.websiteUrl, "_blank");
            }}>
            <img src={partner?.logoUrl} alt={`Partner ${index + 1}`} />
          </figure>
        ))}
      </div>
    </div>
  );
};

export default Partners;
