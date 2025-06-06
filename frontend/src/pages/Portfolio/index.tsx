import axios from 'axios';
import Main from '../../layout/Main'
import style from './index.module.scss';
import { baseUrl } from '../../utils/baseUrl';
import { useEffect, useState } from 'react';
import { FileItem, IPortfolio } from './types';
import Loading from '../../components/Loading/Loading';

const Portfolio = () => {
    const [portfolios, setPortfolios] = useState<IPortfolio[]>([]);
    const [loading, setLoading] = useState(false);

    const fetchData = async () => {
        setLoading(true);
        await axios.get(baseUrl + "/portfolios").then(res => {
            setPortfolios(res?.data?.data)
        })
        setLoading(false);
    }

    useEffect(() => {
        fetchData();
    }, [])

    if (loading) return <Loading />

    return (
        <Main>
            <div className={style.portfolio}>
                <h2 className={style.portfolioTitle}>Portfolio</h2>

                {portfolios?.map((portfolio: IPortfolio, idx: number) => (
                    <div key={idx} className={style.portfolioItem}>
                        <div className={style.portfolioImages}>
                            {portfolio.files?.map((file: FileItem, i: number) => (
                                <figure key={i}>
                                    <img src={file?.path} alt={`Portfolio image ${i + 1}`} />
                                </figure>
                            ))}
                        </div>
                        <hr className={style.element} />
                        <div className={style.portfolioValue}>
                            <h2 className={style.portfolioValueTitle}>{portfolio.name}</h2>
                            <ul>
                                <li>{portfolio.description}</li>
                            </ul>
                        </div>
                    </div>
                ))}
            </div>

        </Main>
    )
}

export default Portfolio
