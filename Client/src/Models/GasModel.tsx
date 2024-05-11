interface GasFuelModel {
    cO2: number;
    co: number;
    h2: number;
    cH4: number;
    c2H6: number;
    c3H8: number;
    c4H10: number;
    c5H12: number;
    h2S: number;
    n2: number;
    h2O: number;
    g: number;
    tг: number;
    tв: number;
    alfa: number;
  }
  
  interface GasModel {
    name: string;
    description: string;
    typeCalculation: string;
    userId: number;
    isActive: boolean;
    gasFuelModel: GasFuelModel;
  }