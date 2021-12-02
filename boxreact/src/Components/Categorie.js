import Button from "react-bootstrap/Button";

const Categorie = ({ cat, getStk }) => {
  return (
    <>
      <Button
        onClick={() => getStk(cat.id)}
        style={{ margin: "0.5rem" }}
        variant="outline-info"
      >
        {cat.name}
      </Button>
    </>
  );
};

export default Categorie;
