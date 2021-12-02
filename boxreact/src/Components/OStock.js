import React from 'react'
import Button from "react-bootstrap/Button";

const OStock = ({ Stk, somme }) => {
  return (
    <>
      <Button
        onClick={() => somme(Stk.Stock.Hauteur * Stk.Stock.Largeur)}
        style={{ margin: "0.5rem" }}
        variant="outline-info"
      >
        {Stk.Stock.Name}
      </Button>
    </>
  );
};

export default OStock
