import style from "./index.module.scss";

const AboutProject = ({ project }: any) => {

    const mainImage = project?.files.find((file: any) => file?.isMain);

    return (
        <div className={style.aboutImages}>
            <div className={style.mainImages}>

                <figure className={style.mainImage}>
                    <img src={mainImage?.path} />
                </figure>

                <div className={style.otherImages}>
                    {project?.files
                        ?.filter((item: any) => item.isMain === false).slice(0, 2) // isMain true-dursa çıxardırıq, false-ları saxlayırıq
                        .map((file: any) => (
                            <figure key={file.id}>
                                <img src={file?.path} alt="other image" />
                            </figure>
                        ))}
                </div>
            </div>

            <div className={style.detail}>

                <h3 className={style.organisationName}>{project?.organisationName}</h3>
                <h3 className={style.name}>{project?.name}</h3>
                <p className={style.description}>{project?.description}</p>

                <hr className={style.detailElement} />

                <div className={style.detailContent}>

                    <div>
                        <h3>Əməkdaş sayı</h3>
                        <h3 className={style.employeeNumber}>{project?.employeeNumber}</h3>
                    </div>

                    <div>
                        <h3>Layihənin müddəti</h3>
                        <h3>{project?.employeeNumber}</h3>
                    </div>

                    <div>
                        <h3>İstifadə olunan materiallar</h3>
                        <h3>{project?.date}</h3>
                    </div>

                    <div>
                        <h3>Təhvil tarixi</h3>
                        <h3>{project?.deliveryDate?.split("T")[0]}</h3>
                    </div>

                </div>

            </div>

        </div>
    )
}

export default AboutProject