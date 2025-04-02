import Main from '../../layout/Main'
import style from './index.module.scss';

const Portfolio = () => {
    return (
        <Main>
            <div className={style.portfolio}>

                <h2 className={style.portfolioTitle}>
                    Portfolio
                </h2>

                <div className={style.portfolioImages}>
                    {[...Array(3)].map((_) => (
                        <figure>
                            <img src={"https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcQ1zwhySGCEBxRRFYIcQgvOLOpRGqrT3d7Qng&s"} />
                        </figure>
                    ))}
                </div>

                <div className={style.portfolioValue}>
                    <h2 className={style.portfolioValueTitle}>Taghiyev Operating Company / Salyan OIL Limited</h2>
                    <ul>
                        {[...Array(6)].map((_, index) => (
                            <li className={style.portfolioValueContent} key={index}>Həcmi 30.000m3-dək olan rezervuarların quraşdırılması və təmiri</li>
                        ))}
                    </ul>
                </div>

            </div>

            <hr className={style.element} />



            <div className={style.portfolio}>
                <div className={style.portfolioImages}>
                    {[...Array(1)].map((_) => (
                        <figure>
                            <img src={"https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcQ1zwhySGCEBxRRFYIcQgvOLOpRGqrT3d7Qng&s"} />
                        </figure>
                    ))}
                </div>
                <div className={style.portfolioValue}>
                    <h2 className={style.portfolioValueTitle}>Taghiyev Operating Company / Salyan OIL Limited</h2>
                    <ul>
                        {[...Array(6)].map((_, index) => (
                            <li className={style.portfolioValueContent} key={index}>Həcmi 30.000m3-dək olan rezervuarların quraşdırılması və təmiri</li>
                        ))}
                    </ul>
                </div>
            </div>



        </Main>
    )
}

export default Portfolio
