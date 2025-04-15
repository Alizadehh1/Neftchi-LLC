import { useRef } from 'react'
import style from './index.module.scss';
import { FaArrowRight, FaArrowLeft } from "react-icons/fa6";
import { useNavigate } from 'react-router-dom';
import { EQUIPMENT_PATH } from '../../utils/routes';


const Equipments = () => {
    const navigate = useNavigate();

    const imageListRef = useRef<HTMLDivElement | null>(null);

    const scroll = (direction: "left" | "right") => {
        if (!imageListRef.current) return;

        const scrollAmount = imageListRef.current.clientWidth * 0.2;
        imageListRef.current.scrollBy({
            left: direction === "right" ? scrollAmount : -scrollAmount,
            behavior: "smooth",
        });
    };

    return (
        <div className={style.equipment}>

            <div className={style.equipmentTitle}>
                <h2 style={{ visibility: "hidden" }}>asfasf</h2>
                <h2 className={style.equipMentTitleValue}>Texnika və avadanlıqlar</h2>
                <div onClick={() => navigate(EQUIPMENT_PATH)} className={style.equipmentMore}>
                    Daha çox məlumat al
                </div>
            </div>

            <div className={style.equipmentImages}>

                <div onClick={() => scroll("left")} className={style.equipmentRightArrow}>
                    <FaArrowLeft />
                </div>

                <div ref={imageListRef} className={style.elements}>
                    {[...Array(15)].map((_) => (
                        <figure>
                            <img src={"https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcQ1zwhySGCEBxRRFYIcQgvOLOpRGqrT3d7Qng&s"} />
                        </figure>
                    ))}

                    <div
                        onClick={() => navigate(EQUIPMENT_PATH)}
                        className={style.equipmentMoreResponsive}
                    >
                        Daha çox məlumat al
                    </div>

                </div>

                <div onClick={() => scroll("right")} className={style.equipmentLeftArrow}>
                    <FaArrowRight />
                </div>

            </div>

        </div>
    )
}

export default Equipments
