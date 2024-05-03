import Footer from "../components/Footer";
import Header from "../components/Header";

const RootLayout = () => {
  return (
    <div className="min-h-screen flex flex-col">
      <Header />
      <div className="flex-grow">
        {}
        <Outlet />
      </div>
      <Footer />
    </div>
  );
};

export default RootLayout;
