import { useEffect, useRef, useState } from "react";
import Main from "../../layout/Main";
import style from "./index.module.scss";
import { useDispatch, useSelector } from "react-redux";
import { setScrollTarget } from "../../store/global";
import Activities from "../../components/About/Activities/Activities";
import { FileItem, ILicense, IRecommendation, ISertificate } from "./types";
import axios from "axios";
import { baseUrl } from "../../utils/baseUrl";
import Loading from "../../components/Loading/Loading";
import { IAbout } from "../../components/Home/AboutUses/types";

const About = () => {
  const dispatch = useDispatch();

  const scrollTarget = useSelector((state: any) => state.scroll.target);

  const licenseRef = useRef<HTMLDivElement>(null);
  const isoRef = useRef<HTMLDivElement>(null);
  const recommendationRef = useRef<HTMLDivElement>(null);

  const [licences, setLicences] = useState<ILicense[]>([]);
  const [sertificates, setSertificates] = useState<ISertificate[]>([]);
  const [aboutUses, setAboutUses] = useState<IAbout[]>([]);
  const [recommendations, setRecommendations] = useState<IRecommendation[]>([]);
  const [loading, setLoading] = useState(false);

  const fetchLisenceData = async () => {
    setLoading(true);
    await axios.get(baseUrl + "/licences").then((res) => {
      setLicences(res?.data?.data);
    });
    setLoading(false);
  };

  const fetchAboutUsesData = async () => {
    setLoading(true);
    await axios.get(baseUrl + "/aboutuses").then((res) => {
      setAboutUses(res?.data?.data);
    });
    setLoading(false);
  };

  const fetchSertificatesData = async () => {
    setLoading(true);
    await axios.get(baseUrl + "/certificates").then((res) => {
      setSertificates(res?.data?.data);
    });
    setLoading(false);
  };

  const fetchRecommendationData = async () => {
    setLoading(true);
    await axios.get(baseUrl + "/recommendations").then((res) => {
      setRecommendations(res?.data?.data);
    });
    setLoading(false);
  };

  useEffect(() => {
    const fetchData = async () => {
      await Promise.allSettled([
        fetchLisenceData(),
        fetchSertificatesData(),
        fetchRecommendationData(),
        fetchAboutUsesData(),
      ]);
      setLoading(false);
    };

    fetchData();
  }, []);

  useEffect(() => {
    if (scrollTarget) {
      let targetRef: HTMLDivElement | null = null;
      if (scrollTarget === "license") targetRef = licenseRef.current;
      else if (scrollTarget === "iso") targetRef = isoRef.current;
      else if (scrollTarget === "recommendation")
        targetRef = recommendationRef.current;

      if (targetRef) {
        targetRef.scrollIntoView({ behavior: "smooth", block: "start" });
        dispatch(setScrollTarget(null));
      }
    }
  }, [scrollTarget, dispatch]);

  if (loading) return <Loading />;

  return (
    <Main>
      <div className={style.about}>
        <h2 className={style.aboutTitle}>{aboutUses[0]?.title}</h2>
        <div
          className={style.aboutMenu}
          dangerouslySetInnerHTML={{ __html: aboutUses[0]?.content }}
        />

        <div className={style.aboutImage}>
          <img src={aboutUses[0]?.imagePath} alt={aboutUses[0]?.title} />
        </div>
      </div>

      <hr />

      <Activities />

      <div ref={licenseRef} className={style.lissenzia}>
        <h2>Lisenziya</h2>
        <div className={style.lisensiaImages}>
          {licences?.map((lisence: ILicense) =>
            lisence?.files?.map((file: FileItem) => (
              <figure>
                <img src={file?.path} />
              </figure>
            ))
          )}
        </div>
      </div>

      <div ref={isoRef} className={style.lissenzia}>
        <h2>ISO sertifikatları</h2>
        <div className={style.lisensiaImages}>
          {sertificates?.map((sertificate: ISertificate) =>
            sertificate?.files?.map((file: FileItem) => (
              <figure>
                <img src={file?.path} />
              </figure>
            ))
          )}
        </div>
      </div>

      <div ref={recommendationRef} className={style.lissenzia}>
        <h2>Tövsiyyə məktubları</h2>
        <div className={style.lisensiaImages}>
          {recommendations?.map((recommendation: IRecommendation) =>
            recommendation?.files?.map((file: FileItem) => (
              <figure>
                <img src={file?.path} />
              </figure>
            ))
          )}
        </div>
      </div>
    </Main>
  );
};

export default About;
