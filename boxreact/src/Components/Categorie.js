import Button from "react-bootstrap/Button";
import React from "react";

const Categorie = ({ cat }) => {
    
    const getStock =(id)=>{
        fetch("https://localhost:7029/api/Categories/"+id).then((res) => res.json()).then(e=>console.log(e))
    }
  return (
    <>
      <Button
        onClick={()=>getStock(cat.id)}
        style={{ margin: "0.5rem" }}
        variant="outline-info"
      >
        {cat.name}
      </Button>
    </>
  );
};

export default Categorie;
