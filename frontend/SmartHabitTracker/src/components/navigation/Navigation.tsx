import { Link } from 'react-router';

const Navigation = () => {
  return (
    <nav className="bg-gray-300 w-full h-16 flex items-center px-6">
      <div>
        <div>Hamburger menu</div>
      </div>
      <div className="flex-1"></div>
      <div className="flex gap-4">
        <Link to={'/'} className="text-lg font-semibold">
          Home
        </Link>
        <Link to={'/Signin'} className="text-lg">
          Signin
        </Link>
        <Link to={'/Signup'} className="text-lg">
          Signup
        </Link>
      </div>
    </nav>
  );
};

export default Navigation;
