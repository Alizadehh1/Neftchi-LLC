import { useRef } from 'react'
import style from './index.module.scss';
import { FaArrowRight, FaArrowLeft } from "react-icons/fa6";

const Partners = () => {
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
        <div className={style.partners}>

            <div className={style.partnersTitle}>
                <h2 style={{ visibility: "hidden" }}>asfasf</h2>
                <h2 className={style.partnersTitleValue}>Partnyorlarımız</h2>
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
                {[...Array(12)].map((_, index) => (
                    <figure key={index}>
                        <img
                            src="https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcQ1zwhySGCEBxRRFYIcQgvOLOpRGqrT3d7Qng&s"
                            alt={`Partner ${index + 1}`}
                        />
                    </figure>
                ))}
            </div>

        </div>
    )
}

export default Partners
