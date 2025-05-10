import { useRef } from 'react'
import style from './index.module.scss';
import { FaArrowRight, FaArrowLeft } from "react-icons/fa6";
import { useNavigate } from 'react-router-dom';
import { EQUIPMENT_PATH } from '../../utils/routes';
import { photos } from './utils';


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

            {/* texnika ve avadanliqlar statik olacaq bu sehifede */}
            <div className={style.equipmentTitle}>
                <h2 style={{ visibility: "hidden" }}>asfasf</h2>
                <h2 className={style.equipMentTitleValue}>Texnika və avadanlıqlar</h2>
                <div onClick={() => navigate(EQUIPMENT_PATH)} className={style.equipmentMore}>
                    Daha çox məlumat al
                </div>
            </div>

            <div className={style.equipmentImages}>

                {/* <div onClick={() => scroll("left")} className={style.equipmentRightArrow}>
                    <FaArrowLeft />
                </div> */}

                <div ref={imageListRef} className={style.elements}>
                    {photos?.slice(0, 4).map((value) => (
                        <figure>
                            <img src={value?.photo} />
                        </figure>
                    ))}

                    <div
                        onClick={() => navigate(EQUIPMENT_PATH)}
                        className={style.equipmentMoreResponsive}
                    >
                        Daha çox məlumat al
                    </div>

                </div>

                {/* <div onClick={() => scroll("right")} className={style.equipmentLeftArrow}>
                    <FaArrowRight />
                </div> */}

            </div>

        </div>
    )
}

export default Equipments
